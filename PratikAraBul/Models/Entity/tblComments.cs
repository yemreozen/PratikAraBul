
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace PratikAraBul.Models.Entity
{

using System;
    using System.Collections.Generic;
    
public partial class tblComments
{

    public int CommentId { get; set; }

    public string KullaniciAdi { get; set; }

    public string KullaniciMail { get; set; }

    public string KullaniciYorumu { get; set; }

    public Nullable<int> ComHizmetId { get; set; }



    public virtual tblHizmetler tblHizmetler { get; set; }

}

}
