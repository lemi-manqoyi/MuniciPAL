using Microsoft.AspNetCore.Mvc;
using MuniciPAL.Models;

public class ServiceRequestController : Controller
{
    private BinarySearchTree<ServiceRequest> _serviceRequests;

    public IActionResult Index()
    {
        var serviceRequests = _context.ServiceRequests.ToList();
        var model = serviceRequests.Select(sr => new ServiceRequestModel
        {
            Id = sr.Id,
            Category = sr.Category,
            Status = sr.Status,
            Location = sr.Location
        }).ToList();

        return View(model);
    }
        
        private readonly ServiceRequestManager _serviceRequestManager;

    public ServiceRequestsController(ServiceRequestManager serviceRequestManager)
    {
        _serviceRequestManager = serviceRequestManager;
    }

    public ActionResult Index()
    {
        _serviceRequestManager.DisplayAllIssues();
        return View();
    }

    public ActionResult ViewDetails(int id)
    {
        _serviceRequestManager.ViewIssueDetails(id);
        return View();
    }
}