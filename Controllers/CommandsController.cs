using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    // api/commands
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        // GET api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);

            if (command == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        // POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var command = _mapper.Map<Command>(commandCreateDto);

            _repository.CreateCommand(command);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(command);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var command = _repository.GetCommandById(id);

            if (command == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, command);

            _repository.UpdateCommand(command);
            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> jsonPatchDoc)
        {
            var command = _repository.GetCommandById(id);
            if (command == null)
            {
                return NotFound();
            }

            var commandUpdateDto = _mapper.Map<CommandUpdateDto>(command);
            jsonPatchDoc.ApplyTo(commandUpdateDto, ModelState);

            if (!TryValidateModel(commandUpdateDto))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandUpdateDto, command);

            _repository.UpdateCommand(command);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {

            var command = _repository.GetCommandById(id);
            if (command == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(command);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}