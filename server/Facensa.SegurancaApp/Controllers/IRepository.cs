using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Web;
using Facensa.SegurancaApp.Model;
using Newtonsoft.Json;

namespace Facensa.SegurancaApp.Controllers
{
    public interface IRepository<T>
    {
        void Save(T entity);
        void Delete(T entity);
        void Edit(T oldEntity, T newEntity);
        List<T> GetAll();
        T GetSpecific(Func<T, bool> func);
        List<T> Get(Func<T, bool> func);

    }

    public class LoginJsonRepository : IRepository<LoginModel>
    {
        private readonly string _filePath;
        private StreamReader _streamReader;
        private StreamWriter _streamWriter;
        public LoginJsonRepository(HttpContext context)
        {
            _filePath = context.Server.MapPath("~/App_Data/users.json");
        }

        public void Save(LoginModel entity)
        {
            var allUsers = this.GetAll() ?? new List<LoginModel>();
            allUsers.Add(entity);

            using (_streamWriter = new StreamWriter(_filePath))
            {
                _streamWriter.Write(JsonConvert.SerializeObject(allUsers));
            }
        }

        public void Delete(LoginModel entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(LoginModel oldEntity, LoginModel entity)
        {
            throw new NotImplementedException();
        }

        public List<LoginModel> GetAll()
        {
            using (_streamReader = new StreamReader(_filePath))
            {
                var fileText = _streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<LoginModel>>(fileText);
            }
            
        }

        public LoginModel GetSpecific(Func<LoginModel, bool> func)
        {
            return this.GetAll().FirstOrDefault(func);
        }

        public List<LoginModel> Get(Func<LoginModel, bool> func)
        {
            return this.GetAll().Where(func).ToList();
        }
    }

    public class PasswordJsonRepository : IRepository<PasswordModel>
    {
        private readonly string _filePath;
        private StreamReader _streamReader;
        private StreamWriter _streamWriter;
        public PasswordJsonRepository(HttpContext context)
        {
            _filePath = context.Server.MapPath("~/App_Data/passwords.json");
        }

        public void Save(PasswordModel entity)
        {
            var allPass = this.GetAll();
            allPass.Add(entity);

            using (_streamWriter = new StreamWriter(_filePath))
            {
                _streamWriter.Write(JsonConvert.SerializeObject(allPass));
            }
        }

        public void Delete(PasswordModel entity)
        {
            var allUsers = this.GetAll();
            allUsers.RemoveAll(p => p.Id == entity.Id);

            using (_streamWriter = new StreamWriter(_filePath))
            {
                _streamWriter.Write(JsonConvert.SerializeObject(allUsers));
            }
        }

        public void Edit(PasswordModel oldEntity, PasswordModel entity)
        {
            var allUsers = this.GetAll();
            allUsers.RemoveAll(p => p.Id == oldEntity.Id);
            allUsers.Add(entity);

            using (_streamWriter = new StreamWriter(_filePath))
            {
                _streamWriter.Write(JsonConvert.SerializeObject(allUsers));
            }
        }

        public List<PasswordModel> GetAll()
        {
            using (_streamReader = new StreamReader(_filePath))
            {
                var fileText = _streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<PasswordModel>>(fileText) ?? new List<PasswordModel>();
            }

        }

        public PasswordModel GetSpecific(Func<PasswordModel, bool> func)
        {
            return this.GetAll().FirstOrDefault(func);
        }

        public List<PasswordModel> Get(Func<PasswordModel, bool> func)
        {
            return this.GetAll().Where(func).ToList();
        }
    }
}