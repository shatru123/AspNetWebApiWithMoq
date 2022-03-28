using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Api.Models
{
    public class CommonData 
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}