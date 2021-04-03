using Customer.WEB.Models;
using Customer.WEB.ServiceContact;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Customer.WEB.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpCustomerClient;

        public CustomerController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _httpCustomerClient = _clientFactory.CreateClient(ApiRoutes.CustomerServiceName);
        }
        // GET: CustomerController
        public async Task<ActionResult> Index()
        {
            var response = await _httpCustomerClient.GetAsync(ApiRoutes.Customer.GetAll);
            var result = await response.Content.ReadAsAsync<List<CustomerViewModel>>();
            return View(result);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(CustomerViewModel request)
        {
            try
            {

                var response = await _httpCustomerClient.PostAsJsonAsync(ApiRoutes.Customer.Add, request);
                var result = response.Content.ReadAsAsync<CustomerViewModel>();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(request);
            }
        }

        // GET: CustomerController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var response = await _httpCustomerClient.GetAsync(ApiRoutes.Customer.GetById.Replace("{id}",id.ToString()));
            var result = await response.Content.ReadAsAsync<CustomerViewModel>();
            return View(result);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, CustomerViewModel request)
        {
            try
            {

                var response = await _httpCustomerClient.PutAsJsonAsync(ApiRoutes.Customer.Update, request);
                var result = response.Content.ReadAsAsync<CustomerViewModel>();

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var response = await _httpCustomerClient.GetAsync(ApiRoutes.Customer.GetById.Replace("{id}", id.ToString()));
            var result = await response.Content.ReadAsAsync<CustomerViewModel>();
            return View(result);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, IFormCollection collection)
        {
            try
            {
                var response = await _httpCustomerClient.DeleteAsync(ApiRoutes.Customer.RemoveById.Replace("{id}", id.ToString()));
                var result = response.Content.ReadAsAsync<CustomerViewModel>();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
