using AutoMapper;
using HrTasks.ModelAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrTasks.Services.Services.Base
{
  public  class BaseServices
    {
        protected readonly IUnitofWork _unitofWork;
        protected readonly IMapper _mapper;
       
        //private readonly IHttpContextAccessor httpContextAccessor;
      
        public BaseServices(IMapper mapper, IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            //httpContextAccessor = new HttpContextAccessor();
           
        }
    }
}
