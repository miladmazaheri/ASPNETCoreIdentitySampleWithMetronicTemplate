﻿using System.Collections.Generic;
using Pars.Entities.Identity;
using cloudscribe.Web.Pagination;

namespace Pars.ViewModels.Identity
{
    public class PagedAppLogItemsViewModel
    {
        public PagedAppLogItemsViewModel()
        {
            Paging = new PaginationSettings();
        }

        public string LogLevel { get; set; } = string.Empty;

        public List<AppLogItem> AppLogItems { get; set; }

        public PaginationSettings Paging { get; set; }
    }
}