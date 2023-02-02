using FinancialControl.Domain.Business.Interfaces;
using FinancialControl.Domain.Business.Requests.Category;
using FinancialControl.Domain.Business.Responses.Category;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FinancialControl.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryBusiness _categoryBusiness;

        public CategoryController(ILogger<BaseController> logger, ICategoryBusiness cashierBusiness
            ) : base(logger)
        {
            _categoryBusiness = cashierBusiness;
        }

        [HttpGet]
        [Route("{categoryId:int}")]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int categoryId)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - GET");
                Logger.LogInformation($"categoryId: {categoryId}");
                return ResultWhenSearching(await _categoryBusiness.GetById(categoryId));
            }
            catch (Exception ex)
            {
                var message = $"Error to get category by id: {categoryId}";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(CreateCategoryResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - POST");
                return ResultWhenAdding(await _categoryBusiness.Create(request));
            }
            catch (Exception ex)
            {
                var message = "Error to add new Category";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(typeof(UpdateCategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryRequest request)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Update)} - PUT");
                return ResultWhenUpdating(await _categoryBusiness.Update(request));
            }
            catch (Exception ex)
            {
                var message = "Error to update Category";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [HttpGet]
        [Route("search/{search:alpha}")]
        [ProducesResponseType(typeof(CategoryResponse[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Filter([FromBody] string search)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Filter)} - GET");
                return ResultWhenSearching(await _categoryBusiness.Filter(search));
            }
            catch (Exception ex)
            {
                var message = $"Error filter Categories, parameter -> {search}";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }
    }
}
