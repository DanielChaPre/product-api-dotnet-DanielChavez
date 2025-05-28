﻿using System;
using System.Collections.Generic;

namespace product_api_dotnet_DanielChavez.Models.DB;

public partial class Product
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public int Activo { get; set; }
}
