import { createSlice } from "@reduxjs/toolkit";
import settingService from "../../services/settings";

const settingSlice = createSlice({
  name: "settings",
  initialState: [],
  reducers: {
    appendSetting(state, action) {
      state.push(action.payload);
    },
    setSettings(state, action) {
      return action.payload;
    },
    editSetting(state, action) {
      const id = action.payload.id;
      return state.map((c) => (c.id == id ? action.payload : c));
    },
    removeSetting(state, action) {
      const id = action.payload.id;
      return state.filter((c) => c.id != id);
    },
  },
});

export const initializeSettings = () => {
  return async (dispatch) => {
    const settings = await settingService.getAll();
    dispatch(setSettings(settings));
  };
};

export const createSetting = (object) => {
  console.log(object);
  return async (dispatch) => {
    const newSetting = await settingService.create(object);
    dispatch(appendSetting(newSetting));
  };
};

export const updateSetting = (object) => {
  return async (dispatch) => {
    await settingService.update(object);
    dispatch(editSetting(object));
  };
};

export const deleteSetting = (id) => {
  return async (dispatch) => {
    await settingService.remove(id);
    dispatch(removeSetting({ id }));
  };
};

export const { appendSetting, editSetting, setSettings, removeSetting } =
  settingSlice.actions;
export default settingSlice.reducer;
