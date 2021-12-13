using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Online_Booking_System_.Models;
using System.Data.Entity;

namespace Online_Booking_System_.Controllers
{
    public class BookingsController : Controller
    {
        OnlineBookingSystemEntities _context = new OnlineBookingSystemEntities();
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(USER log)
        {
            var users = _context.USERs.Where(x=>x.USERNAME==log.USERNAME&&x.PASSWORD==log.PASSWORD).Count();
            if (users > 0)
            {
                return RedirectToAction("TodaySchedule");
            }
            else
            {
                return View();
            }

        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(USER user)
        {
            if (ModelState.IsValid)
            {
                if (UserExists(user.USERNAME, user.EMAIL_ADDRESS)==false)
                {
                    _context.USERs.Add(user);
                    _context.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    return RedirectToAction("Register");
                }
            }
            return View(user);
        }
        public ActionResult TodaySchedule()
        {
            return View(_context.BOOKINGS.Where(x=>x.BOOKING_DATE==DateTime.Today).ToList());
        }

        public bool UserExists(string Username,string Email)
        {
            return _context.USERs.Any(d => d.EMAIL_ADDRESS == Email || d.USERNAME == Username);
        }

        public ActionResult NewMeeting()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMeeting(BOOKING app)
        {
            if (ModelState.IsValid)
            {
                _context.BOOKINGS.Add(app);
                _context.SaveChanges();
                return RedirectToAction("AllMeetings");
            }
            else
            {
                return View();
            }
        }

        public ActionResult AllMeetings()
        {
            //ViewBag.Mesaage = _context.USERS.Where(x => x.UID == id).FirstOrDefault();
            return View(_context.BOOKINGS.ToList());
        }

        public ActionResult AllClients()
        {
            
            return View(_context.CLIENTS.ToList());
        }

        public ActionResult NewClient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewClient(CLIENT cli)
        {
            if (ModelState.IsValid)
            {
                _context.CLIENTS.Add(cli);
                _context.SaveChanges();
                return RedirectToAction("AllClients");
            }
            else
            {
                return View();
            }
        }

        public ActionResult NewBooking()
        {
            //List<>
            return View();
        }

        [HttpPost]
        public ActionResult NewBooking(BOOKING booking)
        {
            if (ModelState.IsValid)
            {
                _context.BOOKINGS.Add(booking);
                _context.SaveChanges();
                return RedirectToAction("AllMeetings");
            }
            else
            {
                return View();
            }
        }

        public ActionResult UpdateBooking(int id)
        {
            return View(_context.BOOKINGS.Where(x=>x.BKID==id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult UpdateBooking(int id,BOOKING booking)
        {
            try
            {
                _context.Entry(booking).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("AllMeetings");
            }
            catch 
            {

                return View();
            }
           
        }

        public ActionResult BookingDetail(int id)
        {
            return View(_context.BOOKINGS.Where(x=>x.BKID==id).FirstOrDefault());
        }

        public ActionResult DeleteBooking(int id)
        {
            return View(_context.BOOKINGS.Where(x => x.BKID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult DeleteBooking(int id,FormCollection formCollection)
        {
            try
            {
                BOOKING booking=_context.BOOKINGS.Where(x=>x.BKID==id).FirstOrDefault();
                _context.BOOKINGS.Remove(booking);
                _context.SaveChanges();
                return RedirectToAction("AllMeetings");
            }
            catch 
            {
                return View();
            }
        }


        public ActionResult SearchBooking(string search)
        {
            return View(_context.BOOKINGS.Where(y => y.SUBJECT == search).ToList());
        }

           public ActionResult DeleteClient(int id)
        {
            return View(_context.CLIENTS.Where(x => x.CLIENT_ID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult DeleteClient(int id,FormCollection formCollection)
        {
            try
            {
                CLIENT cli=_context.CLIENTS.Where(x=>x.CLIENT_ID==id).FirstOrDefault();
                _context.CLIENTS.Remove(cli);
                _context.SaveChanges();
                return RedirectToAction("AllClients");
            }
            catch 
            {
                return View();
            }
        }

    }
}