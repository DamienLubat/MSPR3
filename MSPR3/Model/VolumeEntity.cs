namespace MSPR3.Model
{
    public class VolumeEntity
    {
        public int IDVolume { get; set; }
        public string? VolumeDescription { get; set; }
        public float VolumeWeight { get; set; }
        public string? Dimension { get; set; }

        public string CreatedEntity()
        {
            return "INSERT INTO Volumes(VolumeDescription, VolumeWeight, Dimension) VALUES (@VolumeDescription, @VolumeWeight, @Dimension)";
        }
        public string ReadEntity()
        {
            return "SELECT IDVolume, VolumeDescription, VolumeWeight, Dimension FROM Volumes WHERE IDVolume = @IDVolume";
        }
        public string UpdateEntity()
        {
            return "UPDATE Volumes SET VolumeDescription = @VolumeDescription, VolumeWeight = @VolumeWeight, Dimension = @Dimension WHERE IDVolume = @IDVolume";
        }
        public string DeleteEntity()
        {
            return "DELETE FROM Volumes WHERE IDVolume = @IDVolume";
        }
    }
}
