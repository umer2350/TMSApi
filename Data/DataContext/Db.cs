namespace Data.DataContext
{
    public static class Db
    {

        public static TMSContext Create()
        {
            try
            {
                TMSContext db = new TMSContext();
                return db;
            }
            catch { return null; }
        }
    }
}
