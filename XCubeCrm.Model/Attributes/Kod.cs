﻿using System;
using System.Linq;

namespace XCubeCrm.Model.Attributes
{
    public class Kod : Attribute
    {
        public string Description { get; }
        public string ControlName { get; }
        /// <summary>
        /// Validation işlemleri sırasında zorunlu olan alanları işaretlemek için Kullanılacak.
        /// </summary>
        /// <param name="description"> Uyarı Mesajında Gösterilecek Olan açıklama </param>
        /// <param name="controlName"> uyarı mesajı sonrası focuslanılacak alan Control Adı </param>

        public Kod(string description, string controlName)
        {
            Description = description;
            ControlName = controlName;
        }
    }
}
