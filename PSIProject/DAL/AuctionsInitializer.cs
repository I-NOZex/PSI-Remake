using System.Data.Entity;
using System.Collections.Generic;

using PSIProject.Models.Locations;
using PSIProject.Models.Users;
using System;
namespace PSIProject.DAL {
    public class AuctionsInitializer : DropCreateDatabaseIfModelChanges<AuctionsContext> {
        protected override void Seed(AuctionsContext context) {
 
        }
    }
}