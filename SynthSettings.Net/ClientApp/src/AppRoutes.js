import Home from "./components/Home";
import About from "./components/About";
import Setting from "./components/Setting";
import SettingCreate from "./components/SettingCreate";
import SettingUpdate from "./components/SettingUpdate";

const AppRoutes = [
  {
    index: true,
    element: <Home />,
    path: "/",
  },
  {
    index: true,
    element: <About />,
    path: "/about",
  },
  {
    index: true,
    element: <SettingCreate />,
    path: "/setting/create",
  },
  {
    index: true,
    element: <Setting />,
    path: "/setting/:id",
  },
  {
    index: true,
    element: <SettingUpdate />,
    path: "/setting/:id/edit",
  },
];

export default AppRoutes;
