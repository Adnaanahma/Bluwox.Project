using System.Collections.Immutable;
using Bluwox.Migrations;
using Bluwox.Model.Dtos;
using Bluwox.Model.Entities;
using Bluwox.Model.ViewModels;
using Bluwox.Repository.Cache;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Bluwox.Repository.ServiceManagementRepo
{
    public class ServiceManagementRepo: IServiceManagementRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public ServiceManagementRepo(ApplicationDbContext dbContext, ICacheService cache)
        {
            _dbContext = dbContext;
        }

        // add service repository
        public async Task<bool> Add(string name, long catId, decimal baseFare)
        {
            try
            {
                ServiceManagement serviceManagement = new ServiceManagement
                {
                    Name = name,
                    CategoryId = catId,
                    BaseFare = baseFare
                };

                await _dbContext.ServiceManagements.AddAsync(serviceManagement);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                //log
                throw;
            }
        }

        // update service repository
        public async Task<bool> Update(ServiceManagement serviceManagement)
        {
            try
            {
                _dbContext.ServiceManagements.Update(serviceManagement);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                //log
                throw;
            }
        }

        // activate-deactivate status repository
        public async Task<bool> ActivateAndDeactivate(ServiceManagement serviceManagement)
        {
            try
            {
                _dbContext.ServiceManagements.Update(serviceManagement);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                //log
                throw;
            }
        }

        // get servcie repository
        public async Task<ServiceManagement> Get(long id)
        {
            try
            {
                return await _dbContext.ServiceManagements.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                //log
                throw;
            }
        }

        // load servcie page repository
        public async Task<PagedResult<ServiceManagement>> GetAll(int pageNumber, int pageSize)
        {
            try
            {
                if (pageNumber <= 0) pageNumber = 1;
                if (pageSize <= 0) pageSize = 10;

                var query = _dbContext.ServiceManagements
                    .Include(x => x.Category)
                        .ThenInclude(c => c.SubCategories)
                    .AsQueryable();

                var totalCount = await query.CountAsync();

                var items = await query
                    .OrderBy(x => x.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new PagedResult<ServiceManagement>
                {
                    Data = items,
                    CurrentPage = pageNumber,
                    HasNextPage = (pageNumber * pageSize) < totalCount,
                    TotalRecordInStore = totalCount
                };
            }
            catch (Exception ex)
            {
                // log exception here
                return new PagedResult<ServiceManagement>
                {
                    Data = new List<ServiceManagement>(),
                    CurrentPage = pageNumber,
                    HasNextPage = false,
                    TotalRecordInStore = 0
                };
            }
        }

        /// <summary>
        /// "search service filter"
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="category"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<PagedResult<ServiceManagement>> Filter(string serviceName, long category, DateTime startDate, DateTime endDate, int pageNumber, int pageSize)
        {
            try
            {
                if (pageNumber <= 0) pageNumber = 1;
                if (pageSize <= 0) pageSize = 10;

                var query = _dbContext.ServiceManagements.Include(x => x.Category).ThenInclude(c => c.SubCategories).AsQueryable();

                if (!string.IsNullOrEmpty(serviceName))
                {
                    query = query.Where(x => x.Name == serviceName);
                }

                if (category > 0)
                {
                    query = query.Where(x => x.CategoryId == category);
                }

                if (startDate != null)
                {
                    query = query.Where(x => x.CreatedDate >= startDate);
                }

                if (endDate != null)
                {
                    query = query.Where(x => x.CreatedDate <= endDate);
                }

                var totalCount = query.Count();

                var items = query
                    .OrderBy(x => x.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return new PagedResult<ServiceManagement>
                {
                    Data = items,
                    CurrentPage = pageNumber,
                    HasNextPage = (pageNumber * pageSize) < totalCount,
                    TotalRecordInStore = totalCount
                };
            }
            catch (Exception ex)
            {
                // log exception here
                return new PagedResult<ServiceManagement>
                {
                    Data = new List<ServiceManagement>(),
                    CurrentPage = pageNumber,
                    HasNextPage = false,
                    TotalRecordInStore = 0
                };
            }
        }

        // delete servcie repository
        public async Task<bool> Delete(ServiceManagement serviceManagement)
        {
            try
            {
                _dbContext.ServiceManagements.Remove(serviceManagement);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                //log
                throw;
            }
        }

    }
}
