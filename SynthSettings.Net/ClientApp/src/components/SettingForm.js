import React from "react";

const SettingForm = ({ formData, handleInputChange, handleSubmit }) => {
  return (
    <form onSubmit={handleSubmit}>
      {/* Name */}
      <div className="form-group col-md-6 mb-3">
        <label>Name</label>
        <input
          type="text"
          className="form-control"
          name="name"
          value={formData.name}
          onChange={handleInputChange}
          required
        />
      </div>

      {/* Game Settings */}
      <div className="row">
        <div className="col-md-4">
          <div className="card mb-3">
            <div className="card-header">Oscillator</div>
            <div className="card-body">
              <div className="form-group mb-2">
                <label>Type</label>
                <input
                  type="text"
                  className="form-control"
                  name="oscillator.type"
                  value={formData.oscillator.type}
                  onChange={handleInputChange}
                  required
                />
              </div>
              <div className="form-group mb-2">
                <label>Pitch</label>
                <input
                  type="number"
                  step="0.1"
                  className="form-control"
                  name="oscillator.pitch"
                  value={formData.oscillator.pitch}
                  onChange={handleInputChange}
                  required
                />
              </div>
            </div>
          </div>
        </div>
        <div className="col-md-4">
          <div className="card mb-3">
            <div className="card-header">Envelope</div>
            <div className="card-body">
              <div className="form-group mb-2">
                <label>Amplitude</label>
                <input
                  type="number"
                  step="0.1"
                  className="form-control"
                  name="envelope.amplitude"
                  value={formData.envelope.amplitude}
                  onChange={handleInputChange}
                  required
                />
              </div>
              <div className="form-group mb-2">
                <label>Attack</label>
                <input
                  type="number"
                  step="0.1"
                  className="form-control"
                  name="envelope.adsr.attack"
                  value={formData.envelope.adsr.attack}
                  onChange={handleInputChange}
                  required
                />
              </div>
              <div className="form-group mb-2">
                <label>Delay</label>
                <input
                  type="number"
                  step="0.1"
                  className="form-control"
                  name="envelope.adsr.delay"
                  value={formData.envelope.adsr.delay}
                  onChange={handleInputChange}
                  required
                />
              </div>
              <div className="form-group mb-2">
                <label>Sustain</label>
                <input
                  type="number"
                  step="0.1"
                  className="form-control"
                  name="envelope.adsr.sustain"
                  value={formData.envelope.adsr.sustain}
                  onChange={handleInputChange}
                  required
                />
              </div>
              <div className="form-group mb-2">
                <label>Release</label>
                <input
                  type="number"
                  step="0.1"
                  className="form-control"
                  name="envelope.adsr.release"
                  value={formData.envelope.adsr.release}
                  onChange={handleInputChange}
                  required
                />
              </div>
            </div>
          </div>
        </div>
        <div className="col-md-4">
          <div className="card mb-3">
            <div className="card-header">Filter</div>
            <div className="card-body">
              <div className="form-group mb-2">
                <label>Type</label>
                <input
                  type="text"
                  className="form-control"
                  name="filter.type"
                  value={formData.filter.type}
                  onChange={handleInputChange}
                  required
                />
              </div>
              <div className="form-group mb-2">
                <label>Cutoff</label>
                <input
                  type="number"
                  step="0.1"
                  className="form-control"
                  name="filter.cutoff"
                  value={formData.filter.cutoff}
                  onChange={handleInputChange}
                  required
                />
              </div>
              <div className="form-group mb-2">
                <label>Resonance</label>
                <input
                  type="number"
                  step="0.1"
                  className="form-control"
                  name="filter.resonance"
                  value={formData.filter.resonance}
                  onChange={handleInputChange}
                  required
                />
              </div>
              <div className="form-group mb-2">
                <label>Attack</label>
                <input
                  type="number"
                  step="0.1"
                  className="form-control"
                  name="filter.adsr.attack"
                  value={formData.filter.adsr.attack}
                  onChange={handleInputChange}
                  required
                />
              </div>
              <div className="form-group mb-2">
                <label>Delay</label>
                <input
                  type="number"
                  step="0.1"
                  className="form-control"
                  name="filter.adsr.delay"
                  value={formData.filter.adsr.delay}
                  onChange={handleInputChange}
                  required
                />
              </div>
              <div className="form-group mb-2">
                <label>Sustain</label>
                <input
                  type="number"
                  step="0.1"
                  className="form-control"
                  name="filter.adsr.sustain"
                  value={formData.filter.adsr.sustain}
                  onChange={handleInputChange}
                  required
                />
              </div>
              <div className="form-group mb-2">
                <label>Release</label>
                <input
                  type="number"
                  step="0.1"
                  className="form-control"
                  name="filter.adsr.release"
                  value={formData.filter.adsr.release}
                  onChange={handleInputChange}
                  required
                />
              </div>
            </div>
          </div>
        </div>
      </div>

      {/* Button */}
      <button className="btn btn-info">Save</button>
    </form>
  );
};
export default SettingForm;
