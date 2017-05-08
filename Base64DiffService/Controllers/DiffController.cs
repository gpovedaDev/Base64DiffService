using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Base64DiffService.Model;

namespace Base64DiffService.Controllers
{
    public class DiffController : ApiController
    {
        IDataManager _dataManager;

        public DiffController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }
        /// <summary>
        /// Endpoint used to get diff-ed results
        /// </summary>
        /// <param name="id">Unique id where left and right base64 values are stored in the data collection</param>
        [Route(RouteDefinition.VIEW_DIFFED_RESULTS)]
        [HttpGet]
        public IHttpActionResult GetDiffEdResults(int id)
        {
            Base64Data memoryData;

            memoryData = _dataManager.GetValue(id);

            if (memoryData != null)
            {
                DiffEdResult result = DiffEdTool.CompareBase64(memoryData.Left, memoryData.Right);
                return Ok(result);
            }
            else
                return Ok(ResponseResult.NotFound.ToString());

        }

        /// <summary>
        /// Endpoint used to set the left side
        /// </summary>
        /// <param name="id">Unique id where left and right base64 values are stored in the data collection</param>
        /// <param name="input">Data received from user</param>
        [Route(RouteDefinition.SET_LEFT_SIDE)]
        [HttpPost]
        public IHttpActionResult SetLeft(int id, InputData input)
        {
            return Ok(SetSide(id, input, Side.Left).ToString());
        }

        /// <summary>
        /// Endpoint used to set the right side
        /// </summary>
        /// <param name="id">Unique id where left and right base64 values are stored in the data collection</param>
        /// <param name="input">Data received from user</param>
        [Route(RouteDefinition.SET_RIGHT_SIDE)]
        [HttpPost]
        public IHttpActionResult SetRight(int id, InputData input)
        {
            return Ok(SetSide(id, input, Side.Right).ToString());
        }

        /// <summary>
        /// Sets left and right base64 values
        /// </summary>
        /// <param name="id">unique id</param>
        /// <param name="input">Data received from user</param>
        /// <param name="side">Determines the side to set: left or right</param>
        public ResponseResult SetSide(int id, InputData input, Side side)
        {
            try
            {
                //Base64Data memoryData;
                //DataManagement.DataInstance.TryGetValue(id, out memoryData);

                Base64Data memoryData = _dataManager.GetValue(id);

                if (memoryData == null)
                {
                    Base64Data newData = new Base64Data();

                    switch (side)
                    {
                        case Side.Left:
                            newData.Left = input.Value;
                            break;
                        case Side.Right:
                            newData.Right = input.Value;
                            break;
                    }

                    _dataManager.Add(id, newData);

                    return ResponseResult.Created;
                }
                else
                {
                    Base64Data updatedData = new Base64Data(memoryData);

                    switch (side)
                    {
                        case Side.Left:
                            updatedData.Left = input.Value;
                            break;
                        case Side.Right:
                            updatedData.Right = input.Value;
                            break;
                    }

                    _dataManager.UpdateValue(id, updatedData, memoryData);

                    return ResponseResult.Created;
                }
            }
            catch (Exception ex)
            {
                System.Console.Out.WriteLine(ex);
                return ResponseResult.Error;
            }
        }
    }
}
