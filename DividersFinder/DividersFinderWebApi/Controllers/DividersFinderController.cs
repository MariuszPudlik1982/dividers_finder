using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DividersFinder.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
[assembly: ApiController]
namespace DividersFinderWebApi.Controllers
{

    //[Route("/finddividers")]
    public class DividersFinderController : ControllerBase
    {
       private readonly IFileWriterService _fileWriterService;
       private readonly IDividersFinder _dividersFinder;
       private readonly IJsonDataSerializer _jsonDataSerializer;

        public DividersFinderController(IDividersFinder dividersFinder, IFileWriterService fileWriterService, IJsonDataSerializer jsonDataSerializer)
        {
            _dividersFinder = dividersFinder;
            _fileWriterService = fileWriterService;
            _jsonDataSerializer = jsonDataSerializer;
        }
      [HttpGet("calc/number/{number}")]
        public async Task<List<ulong>> Get(ulong number)
        {
            //_dividersFinder.FindNumbers(number);
            var result= _fileWriterService.WriteText(number);
            return await Task.Run(() => result);
        }
    }
}