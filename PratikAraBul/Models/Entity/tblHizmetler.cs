
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
    
public partial class tblHizmetler
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public tblHizmetler()
    {

        this.tblBasliklar = new HashSet<tblBasliklar>();

        this.tblPopularHizmet = new HashSet<tblPopularHizmet>();

        this.tblComments = new HashSet<tblComments>();

    }


    public int HizmetId { get; set; }

    public string HizmetAdi { get; set; }

    public string HizmetNo { get; set; }

    public Nullable<int> HizmetKategori { get; set; }

    public string HizmetResimUrl { get; set; }

    public string HizmetDesc { get; set; }

    public string BaslikAlti { get; set; }



    public virtual tblHizmetKategori tblHizmetKategori { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tblBasliklar> tblBasliklar { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tblPopularHizmet> tblPopularHizmet { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tblComments> tblComments { get; set; }

}

}
