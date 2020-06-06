using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CRMSystem.Domains;
using CRMSystem.Domains.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using WebApiContrib.Formatting;

namespace CRMSystem.Presentation.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffSkillController : ControllerBase
    {
        private readonly IStaffSkillService _service;
        public StaffSkillController(IStaffSkillService service)
        {
            _service = service;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("Save")]
        public async Task<IActionResult> Save(StaffSkill data)
        {
            var result = await _service.SaveStaffSkill(data);
            return Ok(result);
        }


        /// <summary>
        /// Optional, can be used to add a new assessment, pass the staffskill id and the assessment score (SAS)
        /// Can also be used to update staffskill too
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        public async Task<IActionResult> Update(StaffSkill data)
        {
            var result = await _service.UpdateStaffSkillAsync(data);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllStaffSkill")]
        public async Task<IActionResult> GetAllStaffSkill()
        {

            var result = await _service.GetAllStaffSkillsAsync();
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetStaffSkillByID/{ID}")]
        public async Task<IActionResult> GetStaffSkillByID(int ID)
        {

            var result = await _service.GetStaffSkillByIDAsync(ID);
            return Ok(result);
        }

        //[HttpGet("GetFromServer")]
        //public async Task<IActionResult> GetFromServer()
        //{

        //    var comments = new List<Comment>();
        //    var comms = "";

        //    HttpClient _client = new HttpClient();

        //    _client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

        //    var res =  _client.GetAsync("posts/1/comments");
        //    res.Wait();
        //    var con = res.Result;

        //    if (con.IsSuccessStatusCode)
        //    {
        //        var rest =  con.Content.ReadAsStringAsync();
        //        rest.Wait();

        //        comms = rest.Result;
        //    }
        //    var serializer = new JavaScriptSerializer();

        //    comments = serializer.Deserialize<List<Comment>>(comms);

        //    return Ok(comments);
        //}



        [HttpGet("GetFromServer")]
        public async Task<IActionResult> GetFromServer()
        {
            HttpClient _client = new HttpClient();

            List<Comment> comments = null;


            _client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

           var req= _client.GetAsync("posts/1/comments");
            req.Wait();
            var res = req.Result;

            if (res.IsSuccessStatusCode)
            {

                var con = res.Content.ReadAsStringAsync();
                con.Wait();
                var commentString = con.Result;

                var serializer = new JavaScriptSerializer();
                comments = serializer.Deserialize<List<Comment>>(commentString);
            
            }
            return Ok(comments);
        
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(RequestData request)
        {
            //https://api.sandbox.africastalking.com/version1/messaging

            

            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.sandbox.africastalking.com/");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "version1/messaging");
            _client.DefaultRequestHeaders.Add("apiKey", "a269e0154e849504fffa1c6210890d85e43998c15412248db1612a190b9b44d6");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var nvc = new List<KeyValuePair<string, string>>();
            nvc.Add(new KeyValuePair<string, string>("username", request.username));
            nvc.Add(new KeyValuePair<string, string>("to", request.to));
            nvc.Add(new KeyValuePair<string, string>("message", request.message));

            requestMessage.Content = new FormUrlEncodedContent(nvc);

            var res = await _client.SendAsync(requestMessage);
            string response = null;
            if (res.IsSuccessStatusCode)
            {
                 response = await res.Content.ReadAsStringAsync();
               // response.Wait();

              //  result = JsonConvert.DeserializeObject<SMSMessageData>(response);
                
            }
            return Ok(response);


        }


        [HttpGet("FetchMessage/{username}")]
        public async Task<IActionResult> FetchMessage(string username)
        {

            HttpClient _client = new HttpClient();
            //https://api.sandbox.africastalking.com/version1/messaging

            _client.BaseAddress = new Uri("https://api.sandbox.africastalking.com/");

            var request = new HttpRequestMessage(HttpMethod.Get, "version1/messaging");
            //request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //request.Headers.Add("apiKey", "a269e0154e849504fffa1c6210890d85e43998c15412248db1612a190b9b44d6");

            _client.DefaultRequestHeaders.Add("apiKey", "a269e0154e849504fffa1c6210890d85e43998c15412248db1612a190b9b44d6");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

           // var jsonString = data.ToString();
            request.Content = new StringContent(username, Encoding.UTF8, "application/json");
            var res = "";
            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {

                res = await response.Content.ReadAsStringAsync();

            
            }

            return Ok(res);

        }




















    }
}
