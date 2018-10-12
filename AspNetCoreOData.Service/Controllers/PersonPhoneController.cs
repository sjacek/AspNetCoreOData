﻿
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using  AspNetCoreOData.Service.Database;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;

namespace  AspNetCoreOData.Service.Controllers
{
    public class PersonPhoneController : ODataController
    {
        private AdventureWorks2016Context _db;

        public PersonPhoneController(AdventureWorks2016Context AdventureWorks2016Context)
        {
            _db = AdventureWorks2016Context;
        }

        private static readonly ODataValidationSettings _validationSettings = new ODataValidationSettings();

        [EnableQuery(PageSize = 20)]
        public IActionResult Get()
        {
            return Ok(_db.PersonPhone.AsQueryable());
        }

        [EnableQuery(PageSize = 20)]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_db.PersonPhone.Find(key));
        }
    }
}