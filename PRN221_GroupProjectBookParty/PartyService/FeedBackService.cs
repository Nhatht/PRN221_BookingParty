﻿using PartyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyService
{
    public class FeedBackService : IFeedBackService
    {
        private IFeedBackRepo _feedBackRepo = null;
        public FeedBackService()
        {
            _feedBackRepo = new FeedBackRepo();
        }
    }
}
