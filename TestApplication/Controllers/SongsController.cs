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
    public class SongsController : ControllerBase
    {
        private readonly ISongRepository _repository;
        private readonly ILog _logger;
        public SongsController(ISongRepository repository, ILog logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/Song/GetSongs")]
        public async Task<ActionResult> GetGenres()
        {
            var response = new List<SongVM>();
            try
            {
                response = await _repository.GetSongs();
                _logger.Information("List of Song:" + JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                _logger.Error("Error:" + ex.ToString());
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("api/Song/GetSong")]
        public async Task<ActionResult> GetSong(int id)
        {
            var response = new SongVM();
            try
            {
                _logger.Information("Song request:" + id);
                response = await _repository.GetSong(id);
                _logger.Information("Song response:" + JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                _logger.Error("Error:" + ex.ToString());
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("api/Song/AddSong")]
        public async Task<ActionResult> AddSong(SongVM viewmodel)
        {
            try
            {
                _logger.Information("Song request:" + JsonConvert.SerializeObject(viewmodel));
                await _repository.AddSong(viewmodel);
            }
            catch (Exception ex)
            {
                _logger.Error("Error:" + ex.ToString());
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Song/UpdateSong")]
        public IActionResult UpdateSong(SongVM viewmodel)
        {
            try
            {
                _logger.Information("Song request:" + JsonConvert.SerializeObject(viewmodel));
                _repository.UpdateSong(viewmodel);
            }
            catch (Exception ex)
            {
                _logger.Error("Error:" + ex.ToString());
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Song/DeleteSong")]
        public IActionResult DeleteSong(int id)
        {
            try
            {
                _logger.Information("Song request:" + id);
                _repository.DeleteSong(id);
            }
            catch (Exception ex)
            {
                _logger.Error("Error:" + ex.ToString());
            }
            return Ok();
        }
    }
}
