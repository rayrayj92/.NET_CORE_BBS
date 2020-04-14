using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using esu_v.Infrastructure;
using esu_v.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace esu_v.Controllers
{
    public class BoardController : Controller
    {
        private readonly EsuContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BoardController(EsuContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index(int p = 1)
        {
            int pageSize = 10;
            var boards = _context.Boards.OrderByDescending(x => x.Id).Skip((p - 1) * pageSize).Take(pageSize);
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Boards.Count() / pageSize);
            return View(await boards.ToListAsync());
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Board board)
        {
            if (ModelState.IsValid)
            {
                board.NumViews = 0;

                DateTime localTime = DateTime.Now;

                board.EsuDate = localTime.Date.ToString("yyyy-MM-dd"); // yyyy-mm-dd

                board.EsuFileURL = null;
                board.EsuFile2URL = null;
                board.EsuFile3URL = null;

                string fileName = null;
                string fileName2 = null;
                string fileName3 = null;

                //첫번째 첨부파일
                if(board.EsuUpload != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/board");
                    fileName = board.EsuUpload.FileName;
                    string fn = Guid.NewGuid().ToString() + "_" + fileName;
                    string filePath = Path.Combine(uploadDir, fn);
                    board.EsuFileURL = fn;
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await board.EsuUpload.CopyToAsync(fs);
                    fs.Close();
                }

                //두번째 첨부파일
                if (board.EsuUpload2 != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/board");
                    fileName2 = board.EsuUpload2.FileName;
                    string fn = Guid.NewGuid().ToString() + "_" + fileName2;
                    string filePath = Path.Combine(uploadDir, fn);
                    board.EsuFile2URL = fn;
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await board.EsuUpload2.CopyToAsync(fs);
                    fs.Close();
                }

                //세번째 첨부파일
                if (board.EsuUpload3 != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/board");
                    fileName3 = board.EsuUpload3.FileName;
                    string fn = Guid.NewGuid().ToString() + "_" + fileName3;
                    string filePath = Path.Combine(uploadDir, fn);
                    board.EsuFile3URL = fn;
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await board.EsuUpload3.CopyToAsync(fs);
                    fs.Close();
                }

                board.EsuFile = fileName;
                board.EsuFile2 = fileName2;
                board.EsuFile3 = fileName3;

                _context.Add(board);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(board);
        }

        public async Task<IActionResult> Details(int id)
        {

            Board board = await _context.Boards.FirstOrDefaultAsync(x => x.Id == id);

            if(board == null)
            {
                return NotFound();
            }

            board.NumViews += 1;

            _context.Update(board);
            await _context.SaveChangesAsync();

            return View(board);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Board board = await _context.Boards.FindAsync(id);

            if(board == null)
            {
                return NotFound();
            }

            return View(board);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Board board)
        {

            if (ModelState.IsValid)
            {

                DateTime localTime = DateTime.Now;

                board.EsuDate = localTime.Date.ToString("yyyy-MM-dd");

                ////////////////////기존 첨부파일 삭제////////////////////////////

                if (board.EsuFileURL != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/board");
                    string oldFilePath = Path.Combine(uploadDir, board.EsuFileURL);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                if (board.EsuFile2URL != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/board");
                    string oldFilePath = Path.Combine(uploadDir, board.EsuFile2URL);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                if (board.EsuFile3URL != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/board");
                    string oldFilePath = Path.Combine(uploadDir, board.EsuFile3URL);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                ///////////////////////첨부파일 등록, 업로드/////////////////////////

                board.EsuFileURL = null;
                board.EsuFile2URL = null;
                board.EsuFile3URL = null;

                string fileName = null;
                string fileName2 = null;
                string fileName3 = null;

                //첫번째 첨부파일
                if (board.EsuUpload != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/board");
                    fileName = board.EsuUpload.FileName;
                    string fn = Guid.NewGuid().ToString() + "_" + fileName;
                    string filePath = Path.Combine(uploadDir, fn);
                    board.EsuFileURL = fn;
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await board.EsuUpload.CopyToAsync(fs);
                    fs.Close();
                }

                //두번째 첨부파일
                if (board.EsuUpload2 != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/board");
                    fileName2 = board.EsuUpload2.FileName;
                    string fn = Guid.NewGuid().ToString() + "_" + fileName2;
                    string filePath = Path.Combine(uploadDir, fn);
                    board.EsuFile2URL = fn;
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await board.EsuUpload2.CopyToAsync(fs);
                    fs.Close();
                }

                //세번째 첨부파일
                if (board.EsuUpload3 != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/board");
                    fileName3 = board.EsuUpload3.FileName;
                    string fn = Guid.NewGuid().ToString() + "_" + fileName3;
                    string filePath = Path.Combine(uploadDir, fn);
                    board.EsuFile3URL = fn;
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await board.EsuUpload3.CopyToAsync(fs);
                    fs.Close();
                }

                board.EsuFile = fileName;
                board.EsuFile2 = fileName2;
                board.EsuFile3 = fileName3;

                _context.Update(board);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(board);
        }


        public async Task<IActionResult> Delete(int id)
        {
            Board board = await _context.Boards.FindAsync(id);

            if(board.EsuFileURL != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/board");
                string oldFilePath = Path.Combine(uploadDir, board.EsuFileURL);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
            }

            if (board.EsuFile2URL != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/board");
                string oldFilePath = Path.Combine(uploadDir, board.EsuFile2URL);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
            }

            if (board.EsuFile3URL != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/board");
                string oldFilePath = Path.Combine(uploadDir, board.EsuFile3URL);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
            }

            _context.Remove(board);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public IActionResult Gallary()
        {
            return View();
        }
    }
}