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
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistRepository _repository;
        private readonly ILog _logger;
        public ArtistsController(IArtistRepository repository, ILog logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetArtists")]
        //[Route("api/Artist/GetArtists")]
        public async Task<ActionResult> GetArtists()
        {
            var response = new List<ArtistVM>();
            try
            {
                response = await _repository.GetArtists();
                _logger.Information("List of Artist:" + JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                _logger.Error("Error:" + ex.ToString());
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("api/Artist/GetArtist")]
        public async Task<ActionResult> GetArtist(int id)
        {
            var response = new ArtistVM();
            try
            {
                _logger.Information("Artist request:" + id);
                response = await _repository.GetArtist(id);
                _logger.Information("Artist response:" + JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                _logger.Error("Error:" + ex.ToString());
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("api/Artist/AddArtist")]
        public async Task<ActionResult> AddArtist(ArtistVM viewmodel)
        {
            try
            {
                _logger.Information("Artist request:" + JsonConvert.SerializeObject(viewmodel));
                await _repository.AddArtist(viewmodel);
            }
            catch (Exception ex)
            {
                _logger.Error("Error:" + ex.ToString());
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Artist/UpdateArtist")]
        public ActionResult UpdateArtist(ArtistVM viewmodel)
        {
            try
            {
                _logger.Information("Artist request:" + JsonConvert.SerializeObject(viewmodel));
                _repository.UpdateArtist(viewmodel);
            }
            catch (Exception ex)
            {
                _logger.Error("Error:" + ex.ToString());
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Artist/DeleteArtist")]
        public ActionResult DeleteArtist(int id)
        {
            try
            {
                _logger.Information("Artist request:" + id);
                _repository.DeleteArtist(id);
            }
            catch (Exception ex)
            {
                _logger.Error("Error:" + ex.ToString());
            }
            return Ok();
        }
    }
}
