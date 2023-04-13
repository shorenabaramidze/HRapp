using HRapplication.DAL;
using HRapplication.Models;
using HRapplication.Models.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRapplication.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;
        public EmployeeController(  EmployeeDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
            if (employeeList != null)

            {
                foreach (var employee in employees)
                {
                    var EmployeeViewModel = new EmployeeViewModel()
                    {
                        Id = employee.Id,
                        IdNumber = employee.IdNumber,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Gender = employee.Gender,
                        Birthdate = employee.Birthdate,
                        Position = employee.Position,
                        Status = employee.Status,
                        RetireDate = employee.RetireDate,
                        TelNumber = employee.TelNumber
                    };
                    employeeList.Add(EmployeeViewModel);
                }
                return View(employeeList);
            }
            return View(employeeList);

        
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        IdNumber = employeeData.IdNumber,
                        FirstName = employeeData.FirstName,
                        LastName = employeeData.LastName,
                        Gender = employeeData.Gender,
                        Birthdate = employeeData.Birthdate,
                        Position = employeeData.Position,
                        Status = employeeData.Status,
                        RetireDate = employeeData.RetireDate,
                        TelNumber = employeeData.TelNumber

                    };

                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Employee added successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "data is not valid";
                    return View();
                }
            }
            catch (Exception exception)
            {

                TempData["errorMessage"] = "data is not valid";
                return View();
            }

        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var employee = _context.Employees.SingleOrDefault(x => x.Id == Id);
                if (employee != null)
                {
                    var employeeView = new EmployeeViewModel()
                    {
                        Id = employee.Id,
                        IdNumber = employee.IdNumber,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Gender = employee.Gender,
                        Birthdate = employee.Birthdate,
                        Position = employee.Position,
                        Status = employee.Status,
                        RetireDate = employee.RetireDate,
                        TelNumber = employee.TelNumber
                    };
                    return View(employeeView);
                }
                else
                {
                    TempData["errorMessage"] = $"Employee data is not available with the Id:{Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception exception)
            {
                TempData["errorMessage"] = exception.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        Id = model.Id,
                        IdNumber = model.IdNumber,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Gender = model.Gender,
                        Birthdate = model.Birthdate,
                        Position = model.Position,
                        Status = model.Status,
                        RetireDate = model.RetireDate,
                        TelNumber = model.TelNumber
                    };

                    _context.Employees.Update(employee);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Employee details updated successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "data is not valid";
                    return View();
                }
            }
            catch (Exception exception)
            {

                TempData["errorMessage"] = exception.Message;
                return View();
            }
        }

            [HttpGet]
            public IActionResult Delete (int Id)
            {
                try
                {
                var employee = _context.Employees.SingleOrDefault(x => x.Id == Id);
                    if (employee !=null)
                    {
                        var employeeView = new EmployeeViewModel()
                        {
                            Id = employee.Id,
                            IdNumber = employee.IdNumber,
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            Gender = employee.Gender,
                            Birthdate = employee.Birthdate,
                            Position = employee.Position,
                            Status = employee.Status,
                            RetireDate = employee.RetireDate,
                            TelNumber = employee.TelNumber
                        };


                    return View(employeeView);
                    }
                    else
                    {
                        TempData["errorMessage"] = $"Employee details not available with the Id:{Id}";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception exception)
                {

                    TempData["errorMessage"] = exception.Message;
                    return RedirectToAction("Index");
                }

            }

        [HttpPost]
        public IActionResult Delete(EmployeeViewModel model)
        {
            try
            {
                var employee = _context.Employees.SingleOrDefault(x => x.Id == model.Id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Emloyee deleted successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Employee details not available with the Id:{model.Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception exception)
            {

                TempData["errorMessage"] = exception.Message;
                return View();
            }


        }
        //search method
        [HttpGet]
        public async Task<IActionResult> Index(string search)
        {
            var employees = from x in _context.Employees select x;

            if (!string.IsNullOrEmpty(search))
            {
                employees = employees.Where(x => x.FirstName.Contains(search));
            }

            var employeeViewModels = await employees
                .Select(x => new EmployeeViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Gender = x.Gender,
                    Birthdate = x.Birthdate,
                    Position=x.Position,
                    RetireDate=x.RetireDate,
                    TelNumber=x.TelNumber
                })
                .ToListAsync();

            ViewData["GetEmployeeDetails"] = search;
            return View(employeeViewModels);
        }




    }

}


