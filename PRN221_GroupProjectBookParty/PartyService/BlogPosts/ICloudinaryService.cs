﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyService.BlogPosts
{
    public interface ICloudinaryService
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
