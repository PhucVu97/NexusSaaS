using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Hosting;
using NexusSaaS.Data;
using NexusSaaS.Entity;
using NexusSaaS.Models;
using NexusSaaS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace NexusSaaS.Repository
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly NexusSaaSDbContext _context;
        private readonly IMapper _mapper;
        private IHostingEnvironment _hosting;

        public FeatureRepository(NexusSaaSDbContext context, IMapper mapper, IHostingEnvironment hosting)
        {
            _context = context;
            _mapper = mapper;
            _hosting = hosting;
        }

        public HttpStatusCode Delete(int id)
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var obj = _context.Features.Find(id);
                    if (obj != null)
                    {
                        _context.Remove(obj);
                        _context.SaveChanges();
                        transaction.Commit();
                        return HttpStatusCode.OK;
                    }
                    return HttpStatusCode.NotFound;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return HttpStatusCode.InternalServerError;
                }
            }
        }

        public HttpStatusCode Delete(string id)
        {
            throw new NotImplementedException();
        }

        public FeatureModel GetById(int id)
        {
            var obj = _context.Features
                .ProjectTo<FeatureModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault(f => f.Id == id);

            if(obj != null)
            {
                return obj;
            }
            return null;
        }

        public FeatureModel GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FeatureModel> List()
        {
            var list = _context.Features
                .ProjectTo<FeatureModel>(_mapper.ConfigurationProvider)
                .ToList();

            if(list != null || list.Count() > 0)
            {
                return list;
            }
            return null;
        }

        public HttpStatusCode Save(FeatureModel objModel)
        {
            if (objModel != null)
            {
                try
                {
                    string uploadImgName = "";
                    if (objModel.Img != null)
                    {
                        var uploadFolder = Path.Combine(_hosting.WebRootPath, "images");
                        uploadImgName = Guid.NewGuid() + "_" + objModel.Img.FileName;
                        var uploadImgPath = Path.Combine(uploadFolder, uploadImgName);
                        objModel.Img.CopyTo(new FileStream(uploadImgPath, FileMode.Create));
                        objModel.ImgUrl = uploadImgName;
                    }
                    var objEntity = _mapper.Map<FeatureEntity>(objModel);
                    _context.Features.Add(objEntity);
                    _context.SaveChanges();
                    return HttpStatusCode.OK;
                }
                catch
                {
                    return HttpStatusCode.InternalServerError;
                }
            }
            return HttpStatusCode.BadRequest;
        }

        public HttpStatusCode Update(FeatureModel objModel)
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (objModel != null)
                    {
                        string uploadImgName = "";
                        if (objModel.Img != null)
                        {
                            var uploadFolder = Path.Combine(_hosting.WebRootPath, "images");
                            uploadImgName = Guid.NewGuid() + "_" + objModel.Img.FileName;
                            var uploadImgPath = Path.Combine(uploadFolder, uploadImgName);
                            objModel.Img.CopyTo(new FileStream(uploadImgPath, FileMode.Create));
                            objModel.ImgUrl = uploadImgName;
                        }
                        var objEntity = _mapper.Map<FeatureEntity>(objModel);
                        _context.Update(objEntity);
                        _context.SaveChanges();
                        transaction.Commit();
                        return HttpStatusCode.OK;
                    }
                    return HttpStatusCode.BadRequest;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    return HttpStatusCode.InternalServerError;
                }
            }
        }
    }
}
