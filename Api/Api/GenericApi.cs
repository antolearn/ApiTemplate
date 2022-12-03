using Api.Core.Repositories;
using Api.Interfaces;
using AutoMapper;

namespace Api.Api
{
    public class GenericApi<T> : IGenericApi<T> where T : class
    {

        public async Task<IResult> AddAsync(T entity)
        {
            
            return Results.Ok("AddAsync");
        }

        public async Task<IResult> GetAllAsync()
        {
            return Results.Ok("GetAllAsync");
        }
    }
}
