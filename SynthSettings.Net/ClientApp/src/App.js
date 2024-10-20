import React, { Component, useEffect } from "react";
import { Route, Routes } from "react-router-dom";
import AppRoutes from "./AppRoutes";
import { Layout } from "./components/Layout";
import "./custom.css";
import { useDispatch } from "react-redux";
import { initializeSettings } from "./redux/reducers/settingReducer";

export default () => {
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(initializeSettings());
  }, [dispatch]);

  return (
    <Layout>
      <Routes>
        {AppRoutes.map((route, index) => {
          const { element, path, ...rest } = route;
          return <Route key={index} {...rest} path={path} element={element} />;
        })}
      </Routes>
    </Layout>
  );
};
