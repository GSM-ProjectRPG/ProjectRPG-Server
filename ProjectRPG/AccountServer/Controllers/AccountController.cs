using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AccountServer.DB;
using SharedDB;

namespace AccountServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AppDbContext _context;
        private SharedDbContext _shared;

        public AccountController(AppDbContext context, SharedDbContext shared)
        {
            _context = context;
            _shared = shared;
        }

        [HttpPost]
        [Route("create")]
        public CreateAccountPacketRes CreateAccount([FromBody] CreateAccountPacketReq req)
        {
            var res = new CreateAccountPacketRes();

            var account = _context.Accounts
                                    .AsNoTracking()
                                    .Where(a => a.AccountName == req.AccountName)
                                    .FirstOrDefault();

            if (account == null)
            {
                _context.Accounts.Add(new AccountDb()
                {
                    AccountName = req.AccountName,
                    Password = req.Password
                });

                bool success = _context.SaveChangesEx();
                res.CreateOk = success;
            }
            else
            {
                res.CreateOk = false;
            }

            return res;
        }

        [HttpPost]
        [Route("login")]
        public LoginAccountPacketRes LoginAccount([FromBody] LoginAccountPacketReq req)
        {
            var res = new LoginAccountPacketRes();

            var account = _context.Accounts
                .AsNoTracking()
                .Where(a => a.AccountName == req.AccountName && a.Password == req.Password)
                .FirstOrDefault();

            if (account == null)
            {
                res.LoginOk = false;
            }
            else
            {
                res.LoginOk = true;

                // 토큰 발급
                var expired = DateTime.UtcNow;
                expired.AddSeconds(600);

                var tokenDb = _shared.Tokens.Where(t => t.AccountDbId == account.AccountDbId).FirstOrDefault();
                if (tokenDb != null)
                {
                    tokenDb.Token = new Random().Next(Int32.MinValue, Int32.MaxValue);
                    tokenDb.Expired = expired;
                    _shared.SaveChangesEx();
                }
                else
                {
                    tokenDb = new TokenDb()
                    {
                        AccountDbId = account.AccountDbId,
                        Token = new Random().Next(Int32.MinValue, Int32.MaxValue),
                        Expired = expired
                    };
                    _shared.Add(tokenDb);
                    _shared.SaveChangesEx();
                }

                res.AccountName = account.AccountName;
                res.Token = tokenDb.Token;
                res.ServerList = new List<ServerInfo>();

                foreach (var serverDb in _shared.Servers)
                {
                    res.ServerList.Add(new ServerInfo()
                    {
                        Name = serverDb.Name,
                        IpAddress = serverDb.IpAddress,
                        Port = serverDb.Port,
                        BusyScore = serverDb.BusyScore
                    });
                }
            }

            return res;
        }
    }
}