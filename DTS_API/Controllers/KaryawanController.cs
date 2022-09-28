using DTS_API.Context;
using DTS_API.Models;
using DTS_API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KaryawanController : ControllerBase
    {
        KaryawanRepository karyawanRepository;

        public KaryawanController(KaryawanRepository karyawanRepository)
        {
            this.karyawanRepository = karyawanRepository;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = karyawanRepository.Get();
            if (data == null)
            {
                return Ok(new { message = "Sukses mengambil data", 
                    StatusCode = 200, data = "null" });
            }
            return Ok(new { message = "Sukses Mengambil data", 
                statusCode = 200, data = data });
        }

        public IActionResult Get(int id)
        {
            var data = karyawanRepository.Get(id);
            if (data == null)
            {
                return Ok(new
                {
                    message = "Sukses mengambil data",
                    StatusCode = 200,
                    data = "null"
                });
            }
            return Ok(new
            {
                message = "Sukses Mengambil data",
                statusCode = 200,
                data = data
            });
        }
        //UPDATE
        [HttpPut]

        public IActionResult Put(Karyawan karyawan)
        {

            var result = karyawanRepository.Put(karyawan);
            if (result > 0)
            {
                return Ok(new { StatusCode = 200, 
                    message = "berhasil mengubah data" });
            }
            return BadRequest(new
            {
                StatusCode = 200,
                message = "gagal mengubah data"
            });
        }
        //CREATE
        [HttpPost]

        public IActionResult Post(Karyawan karyawan)
        {
            var result = karyawanRepository.Post(karyawan);

            if (result > 0)
            {
                return Ok(new
                {
                    StatusCode = 200,
                    message = "berhasil menambah data"
                });
            }
            return BadRequest(new
            {
                StatusCode = 200,
                message = "gagal menambah data"
            });
        }
        //DELETE
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var result = karyawanRepository.Delete(id);
            if (result > 0)
            {
                return Ok(new
                {
                    StatusCode = 200,
                    message = "berhasil menghapus data"
                });
            }
            return BadRequest(new
            {
                StatusCode = 200,
                message = "gagal menhapus data"
            });

        }
    }
}
