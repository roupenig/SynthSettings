import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { Link } from "react-router-dom";

const Setting = () => {
  const { id } = useParams();
  const settings = useSelector((state) => state.settings);
  const setting = settings.filter((c) => c.id == id)[0];
  if (!setting) {
    return null;
  }
  const { name, oscillator, envelope, filter } = setting;

  return (
    <div className="container my-4">
      <h3 className="text-center mb-1">{setting.name}</h3>
      <div className="text-end">
        <Link
          to={`/setting/${setting.id}/edit`}
          className="btn btn-primary my-3"
        >
          Edit
        </Link>
      </div>

      {/* Oscillator */}
      <div className="row">
        <div className="col-md-4">
          <div className="card mb-3">
            <div className="card-header">Oscillator</div>
            <div className="card-body">
              <p>
                <strong>Type:</strong> {oscillator.type}
              </p>
              <p>
                <strong>Pitch:</strong> {oscillator.pitch}
              </p>
            </div>
          </div>
        </div>
        {/* Envelope */}
        <div className="col-md-4">
          <div className="card mb-3">
            <div className="card-header">Envelope</div>
            <div className="card-body">
              <p>
                <strong>Amplitude:</strong> {envelope.amplitude}
              </p>
              <p>
                <strong>Attack:</strong> {envelope.adsr.attack}
              </p>
              <p>
                <strong>Delay:</strong> {envelope.adsr.delay}
              </p>
              <p>
                <strong>Sustain:</strong> {envelope.adsr.sustain}
              </p>
              <p>
                <strong>Release:</strong> {envelope.adsr.release}
              </p>
            </div>
          </div>
        </div>
        {/* Filter Section */}
        <div className="col-md-4">
          <div className="card mb-3">
            <div className="card-header">Filter Settings</div>
            <div className="card-body">
              <p>
                <strong>Type:</strong> {filter.type}
              </p>
              <p>
                <strong>Cutoff:</strong> {filter.cutoff}
              </p>
              <p>
                <strong>Resonance:</strong> {filter.resonance}
              </p>
              <p>
                <strong>Attack:</strong> {filter.adsr.attack}
              </p>
              <p>
                <strong>Delay:</strong> {filter.adsr.delay}
              </p>
              <p>
                <strong>Sustain:</strong> {filter.adsr.sustain}
              </p>
              <p>
                <strong>Release:</strong> {filter.adsr.release}
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
export default Setting;
