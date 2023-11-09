using AutoMapper;
using System;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Agency.Data.MyContext;
using Agency.Agency.Entities;
using Agency.Agency.DTOs;
using Agency.Agency.Repositories;
using Agency.Agency.Interfaces;
using Agency.CommonUtils;

[ApiController]
[Route("api/agencies")]
public class AgencyController : ControllerBase
{
    public readonly IValidator<CreateAgencyRequestDTO> _validator;
    private readonly IAgencyRepository _agencyRepository;
    private readonly IMapper _mapper;
    public AgencyController(IAgencyRepository agencyRepository, IValidator<CreateAgencyRequestDTO> validator, IMapper mapper)
    {
        _agencyRepository = agencyRepository;
        _validator = validator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateAgencyRequestDTO agencyDTO)
    {
        var validationResult = _validator.Validate(agencyDTO);
        if (!validationResult.IsValid)
        {
            return BadRequest(AgencyUtil.GetErrorObject(validationResult));
        }

        var agencyEntity = _mapper.Map<AgencyEntity>(agencyDTO);
        var createdAgency = await _agencyRepository.AddAsync(agencyEntity);

        var response = new ApiResponse<CreateAgencyResponseDTO>(new CreateAgencyResponseDTO
        {
            Name = createdAgency.Name,
            Description = createdAgency.Description,
        }, "Data created in db successfully");
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allAgencies = await _agencyRepository.GetAllAsync();
        return Ok(allAgencies);
    }

    [HttpPut]
    public async Task<IActionResult> Put()
    {
        string sampleResponse = "dddol";
        return Ok(sampleResponse);
    }

}