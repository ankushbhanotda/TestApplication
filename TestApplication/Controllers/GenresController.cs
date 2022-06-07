using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.Logger;
using TestApplication.Models;
using TestApplication.ViewModel;

namespace TestApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _repository;
        private readonly ILog _logger;
        public GenresController(IGenreRepository repository, ILog logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/Genre/GetGenres")]
        public async Task<ActionResult> GetGenres()
        {
            var response = new List<GenreVM>();
            try
            {
                response = await _repository.GetGenres();
                _logger.Information("List of Genre:" + JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                _logger.Error("Error:" + ex.ToString());
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("api/Genre/GetGenre")]
        public async Task<ActionResult> GetGenre(int id)
        {
            var response = new GenreVM();
            try
            {
                _logger.Information("Genre request:" + id);
                response = await _repository.GetGenre(id);
                _logger.Information("Genre response:" + JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                _logger.Error("Error:" + ex.ToString());
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("api/Genre/AddGenre")]
        public async Task<ActionResult> AddGenre(GenreVM viewmodel)
        {
            try
            {
                _logger.Information("BackstreetBoy request:" + JsonConvert.SerializeObject(viewmodel));
                await _repository.AddGenre(viewmodel);
            }
            catch (Exception ex)
            {
                _logger.Error("Error:" + ex.ToString());
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Genre/UpdateGenre")]
        public IActionResult UpdateGenre(GenreVM viewmodel)
        {
            try
            {
                _logger.Information("Genre request:" + JsonConvert.SerializeObject(viewmodel));
                _repository.UpdateGenre(viewmodel);
            }
            catch (Exception ex)
            {
                _logger.Error("Error:" + ex.ToString());
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Genre/DeleteGenre")]
        public IActionResult DeleteGenre(int id)
        {
            try
            {
                _logger.Information("Genre request:" + id);
                _repository.DeleteGenre(id);
            }
            catch (Exception ex)
            {
                _logger.Error("Error:" + ex.ToString());
            }
            return Ok();
        }
    }
}
