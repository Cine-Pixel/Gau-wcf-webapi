﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreServiceClientApp.classes {
    [Serializable]
    public class CategoryDTO {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
