namespace ModeTour.Services
{
    public static class UnitOfWorkFactory
    {
        /// <summary>
        /// Function initialization Unit of work
        /// </summary>
        /// <returns></returns>
        public static UnitOfWorks GetUnitOfWork()
        {
            return new UnitOfWorks();
        }
    }
}
