import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { createSetting } from "../redux/reducers/settingReducer";
import SettingForm from "./SettingForm";

const SettingCreate = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const [formData, setFormData] = useState({
    name: "",
    oscillator: {
      type: "",
      pitch: "",
    },
    envelope: {
      amplitude: "",
      adsr: { attack: "", delay: "", sustain: "", release: "" },
    },
    filter: {
      type: "",
      cutoff: "",
      resonance: "",
      adsr: { attack: "", delay: "", sustain: "", release: "" },
    },
  });

  const handleInputChange = (e) => {
    const { name, value, type, checked } = e.target;
    const newValue = type === "checkbox" ? checked : value;

    const keys = name.split(".");

    setFormData((prev) => {
      let updatedData = { ...prev };

      let nestedData = updatedData;
      for (let i = 0; i < keys.length - 1; i++) {
        nestedData[keys[i]] = { ...nestedData[keys[i]] };
        nestedData = nestedData[keys[i]];
      }
      nestedData[keys[keys.length - 1]] = newValue;

      return updatedData;
    });
  };

  const handleSubmit = (event) => {
    event.preventDefault();

    dispatch(createSetting(formData));
    navigate("/");
  };

  return (
    <div className="container my-4">
      <h2 className="text-center mb-4">Add new setting</h2>
      <SettingForm
        formData={formData}
        handleInputChange={handleInputChange}
        handleSubmit={handleSubmit}
      ></SettingForm>
    </div>
  );
};
export default SettingCreate;
