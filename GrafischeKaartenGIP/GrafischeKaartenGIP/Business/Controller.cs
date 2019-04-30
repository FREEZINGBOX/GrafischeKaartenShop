using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrafischeKaartenGIP.Persistence;

namespace GrafischeKaartenGIP.Business
{
    public class Controller
    {
        PersistenceCode _PersistenceCode = new PersistenceCode();

        public List<Artikel> HaalArtiekelenOp()
        {
            return _PersistenceCode.HaalArtiekelenOp();
        }
    }
}