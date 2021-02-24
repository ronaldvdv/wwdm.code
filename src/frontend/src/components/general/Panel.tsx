import React from "react"

export default ({ title, figure, color, children }) => (
<div className={`panel panel-${color}`}>
    <h3>{title}</h3>
    {figure}
    <div className="panel-body">{children}</div>
</div>
);