import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { Link } from "react-router-dom";
import { deleteSetting } from "../redux/reducers/settingReducer";

const SettingsList = () => {
  const settings = useSelector((state) => state.settings);
  const dispatch = useDispatch();

  const handleDelete = (id) => {
    if (window.confirm("Remove?")) {
      dispatch(deleteSetting(id));
    }
  };

  return (
    <div className="container ">
      <div className="text-end">
        <Link to="/setting/create" className="btn btn-success my-3">
          Create New
        </Link>
      </div>
      <div className="table-responsive">
        <table className="table mx-auto" style={{ width: "50%" }}>
          <thead>
            <tr>
              <th>Name</th>
              <th className="text-end"></th>
            </tr>
          </thead>
          <tbody>
            {settings.map((setting, index) => (
              <tr key={index}>
                <td>{setting.name}</td>
                <td className="text-end">
                  <Link
                    to={`/setting/${setting.id}`}
                    className="btn btn-sm btn-primary ms-2"
                  >
                    View
                  </Link>
                  <Link
                    to={`/setting/${setting.id}/edit`}
                    className="btn btn-sm btn-primary ms-2"
                  >
                    Edit
                  </Link>
                  <button
                    onClick={() => handleDelete(setting.id)}
                    className="btn btn-sm btn-danger ms-2"
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};
export default SettingsList;
