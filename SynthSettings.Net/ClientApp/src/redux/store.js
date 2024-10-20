import { configureStore } from "@reduxjs/toolkit";
import settingReducer from "./reducers/settingReducer";

const store = configureStore({
  reducer: {
    settings: settingReducer,
  },
});

export default store;
