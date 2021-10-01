using BackEnd.CrudMongo.Entities.DbSet;
using BackEnd.CrudMongo.Entities.Interfaces.Business;
using BackEnd.CrudMongo.Entities.Interfaces.Repository;
using BackEnd.CrudMongo.Entities.Response;
using BackEnd.CrudMongo.Repository.Context;
using BackEnd.CrudMongo.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.CrudMongo.Business
{
    public class UsersBusiness : IUsersBusiness
    {
        private readonly IUsersRepository _repository;  //IMongoContextRespository<Users> _respository;
        public UsersBusiness(IUsersRepository repository/*IMongoContextRespository<Users> respository*/)
        {
            _repository = repository;
        }

        public async Task<ResponseBase<Users>> CreateUsers(Users users)
        {
            ResponseBase<Users> response = new ResponseBase<Users>();
            try
            {
                response.Data = await _repository.CreateAsync(users).ConfigureAwait(true);
                if (response.Data != null)
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "Solicitud OK";
                }
                else
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Message = "No existen registros";
                }
            }
            catch (Exception ex)
            {
                response.ResponseBaseCatch<Users>(true, HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        public async Task<ResponseBase<bool>> DeleteUsers(string id)
        {
            ResponseBase<bool> response = new ResponseBase<bool>();
            try
            {
                response.Data = await _repository.DeleteAsync(id).ConfigureAwait(true);
                if (response.Data)
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "Solicitud OK";
                }
                else
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Message = "No actualizo los registros";
                }
            }
            catch (Exception ex)
            {
                response.ResponseBaseCatch<bool>(true, HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        public async Task<ResponseBase<List<Users>>> GetAllUsers()
        {
            ResponseBase<List<Users>> response = new ResponseBase<List<Users>>();
            try
            {
                response.Data = await _repository.GetAllAsync().ConfigureAwait(true);
                if (response.Data.Count > 0)
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "Solicitud OK";
                }
                else
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Message = "No encontro los registros";
                }
            }
            catch (Exception ex)
            {
                response.ResponseBaseCatch<List<Users>>(true, HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        public async Task<ResponseBase<Users>> UpdateUsers(Users users)
        {
            ResponseBase<Users> response = new ResponseBase<Users>();
            try
            {
                response.Data = await _repository.UpdateAsync(users.Id.ToString(), users).ConfigureAwait(true);
                if (response.Data != null)
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "Solicitud OK";
                }
                else
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Message = "No actualizo los registros";
                }
            }
            catch (Exception ex)
            {
                response.ResponseBaseCatch<Users>(true, HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
    }
}
