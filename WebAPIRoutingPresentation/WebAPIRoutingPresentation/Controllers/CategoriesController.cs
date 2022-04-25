﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIRoutingPresentation.EF;
using WebAPIRoutingPresentation.Models;

namespace WebAPIRoutingPresentation.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private readonly StoreModel db = new StoreModel();

        [Route("")]
        public IHttpActionResult GetAllProducts()
        {
            List<CategoryDTO> categories = db.Categories.Select(c => new CategoryDTO {
                Id=c.Id, 
                CategoryName=c.CategoryName
            }).ToList();
            return Json(categories);
        }

    }
}