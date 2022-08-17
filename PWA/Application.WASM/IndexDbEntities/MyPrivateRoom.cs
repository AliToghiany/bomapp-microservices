namespace Application.WASM.IndexDbEntities
{
    public class MyPrivateRoom
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }

        public long WithUserId { get; set; }
        public int NewMessage { get; set; }
    }
}
