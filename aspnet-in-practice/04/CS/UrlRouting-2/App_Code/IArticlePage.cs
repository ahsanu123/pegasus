﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

public interface IArticlePage : IHttpHandler
{
    int Id { get; set; }
	string Description { get; set; }
}
