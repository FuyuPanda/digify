using Digify.Common;
using Digify.API.Model.User;
using Digify.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly DigifyContext db;
        public RegistrationController(DigifyContext ctx)
        {
            db = ctx;
        }
        [AllowAnonymous]
        [HttpPost]
        public BaseResponse Register([FromBody] RegistrationModel model)
        {
            BaseResponse response = ResponseConstant.ERROR;
            var user = db.User.Where(a => a.npwp == model.npwp).FirstOrDefault();
            if (user == null)
            {

                using (var dbcxtransaction = db.Database.BeginTransaction())
                {
                    try
                    {

                        user = new User
                        {
                            directorName = model.directorName,
                            npwp = model.npwp,
                            companyName = model.companyName,
                            email = model.email,
                            npwpPath = model.npwpFile,
                            phoneNumber = model.phone,
                            picName = model.picName,
                            poaPath = model.poaFile
                        };
                        db.User.Add(user);
                        db.SaveChanges();
                        dbcxtransaction.Commit();
                        response = ResponseConstant.OK;
                        response.message = "User has been registered successfully";

                    }
                    catch (Exception ex)
                    {
                        dbcxtransaction.Rollback();
                        response.message = ex.Message;
                    }



                }

            }
            else
            {
                response.message="User already exists";
            }


            return response;

        }


    }
}
