using APBD_Z_CW2_s26611.Domain;

namespace APBD_Z_CW2_s26611.doubleerfaces;

public interface IHazardNotifier
{
    void Notify(string message, string cargoName);
}