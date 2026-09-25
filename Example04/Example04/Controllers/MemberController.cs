using Microsoft.AspNetCore.Mvc;
using Example04.Models;

namespace Example04.Controllers
{
    public class MemberController : Controller
    {
        // Danh sách thành viên dùng chung
        public static List<Member> members = new List<Member>()
        {
            new Member()
            {
                MemberId = Guid.NewGuid().ToString(),
                Username = "member1",
                Fullname = "Thành viên 1",
                Password = "123456",
                Email = "tv1@gmail.com"
            },

            new Member()
            {
                MemberId = Guid.NewGuid().ToString(),
                Username = "member2",
                Fullname = "Thành viên 2",
                Password = "123456",
                Email = "tv2@gmail.com"
            },

            new Member()
            {
                MemberId = Guid.NewGuid().ToString(),
                Username = "member3",
                Fullname = "Thành viên 3",
                Password = "123456",
                Email = "tv3@gmail.com"
            },

            new Member()
            {
                MemberId = Guid.NewGuid().ToString(),
                Username = "member4",
                Fullname = "Thành viên 4",
                Password = "123456",
                Email = "tv4@gmail.com"
            },

            new Member()
            {
                MemberId = Guid.NewGuid().ToString(),
                Username = "member5",
                Fullname = "Thành viên 5",
                Password = "123456",
                Email = "tv5@gmail.com"
            }
        };


        // Hiển thị 1 thành viên
        public IActionResult Index()
        {
            var member = new Member();

            member.MemberId = Guid.NewGuid().ToString();
            member.Username = "trinhvanchung";
            member.Password = "password";
            member.Fullname = "Trịnh Văn Chung";
            member.Email = "chungtrinhvan@gmail.com";

            return View(member);
        }


        // Hiển thị danh sách thành viên
        public IActionResult GetMembers()
        {
            return View(members);
        }


        // Hiển thị form thêm
        [HttpGet]
        public IActionResult Create()
        {
            var member = new Member();

            member.MemberId = Guid.NewGuid().ToString();

            return View(member);
        }


        // Xử lý thêm thành viên
        [HttpPost]
        public IActionResult Create(Member member)
        {
            members.Add(member);

            return RedirectToAction("GetMembers");
        }
        public IActionResult Details(string id)
        {
            var member = members.FirstOrDefault(m => m.MemberId == id);

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var member = members.FirstOrDefault(m => m.MemberId == id);

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }
        [HttpPost]
        public IActionResult Edit(Member member)
        {
            var oldMember = members.FirstOrDefault(m => m.MemberId == member.MemberId);

            if (oldMember == null)
            {
                return NotFound();
            }

            oldMember.Username = member.Username;
            oldMember.Fullname = member.Fullname;
            oldMember.Password = member.Password;
            oldMember.Email = member.Email;

            return RedirectToAction("GetMembers");
        }
        public IActionResult Delete(string id)
        {
            var member = members.FirstOrDefault(m => m.MemberId == id);

            if (member == null)
            {
                return NotFound();
            }

            members.Remove(member);

            return RedirectToAction("GetMembers");
        }
    }
}