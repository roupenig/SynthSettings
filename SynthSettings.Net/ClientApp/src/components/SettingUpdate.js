import React, { useState } from "react";
import { updateSetting } from "../redux/reducers/settingReducer";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import SettingForm from "./SettingForm";

const SettingUpdate = () => {
  const { id } = useParams();
  const settings = useSelector((state) => state.settings);
  const setting = settings.filter((c) => c.id == id)[0];
  const [formData, setFormData] = useState(setting);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  if (!setting) {
    return null;
  }

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
    dispatch(updateSetting(formData));
    navigate("/");
  };

  return (
    <div className="container my-4">
      <h2 className="text-center mb-4">Update setting</h2>
      <SettingForm
        formData={formData}
        handleInputChange={handleInputChange}
        handleSubmit={handleSubmit}
      ></SettingForm>
    </div>
  );
};
export default SettingUpdate;
