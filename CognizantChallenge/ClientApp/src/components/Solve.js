import React, { Component } from "react";

export class Solve extends Component {
  static displayName = Solve.name;

  constructor(props) {
    super(props);
    this.state = {
      tasks: [],
      loading: true,
      isTaskSelected: false,
      selectedTask: {},
      submitResult: null,
    };
  }

  componentDidMount() {
    this.populateTasks();
  }

  onTaskChange = (event) => {
    const taskId = event.currentTarget.value;
    if (taskId) {
      this.setState({
        isTaskSelected: true,
        selectedTask: this.state.tasks.find((p) => p.id === taskId),
      });
    } else {
      this.setState({ isTaskSelected: false });
    }
  };

  async onSubmitTask(event) {
    event.preventDefault();
    const formData = new FormData(event.currentTarget);
    const requestInput = {
      userName: formData.get("userName"),
      taskId: formData.get("taskId"),
      code: formData.get("code"),
      language: formData.get("language"),
    };
    const response = await fetch("Task/Submit", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(requestInput),
    });
    const data = await response.json();
    this.setState({ submitResult: data });
  }

  async populateTasks() {
    const response = await fetch("Task/ListTasks");
    const data = await response.json();
    this.setState({ tasks: data.tasks, loading: false });
  }

  render() {
    return this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      <form onSubmit={this.onSubmitTask.bind(this)}>
        <div className="form-group row">
          <label htmlFor="name" className="col-sm-2 col-form-label">
            Username
          </label>
          <div className="col-sm-10">
            <input
              type="text"
              className="form-control"
              id="name"
              name="userName"
              placeholder="Name"
            />
          </div>
        </div>
        <div className="form-group row">
          <label htmlFor="selectTask" className="col-sm-2 col-form-label">
            Select task
          </label>
          <div className="col-sm-10">
            <select
              className="form-control"
              id="selectTask"
              name="taskId"
              onChange={this.onTaskChange}
            >
              <option value={null}></option>
              {this.state.tasks.map((p) => (
                <option key={p.id} value={p.id}>
                  {p.taskName}
                </option>
              ))}
            </select>
          </div>
        </div>
        <div className="form-group row">
          <label htmlFor="language" className="col-sm-2 col-form-label">
            Language
          </label>
          <div className="col-sm-10">
            <select
              className="form-control"
              id="language"
              name="language"
            >
              <option value="csharp">C#</option>
              <option value="java">Java</option>
            </select>
          </div>
        </div>
        {this.state.isTaskSelected && (
          <>
            <fieldset className="form-group row">
              <label className="col-form-label col-sm-2 pt-0">
                Description
              </label>
              <div className="col-sm-10">
                <div className="form-check">
                  {this.state.selectedTask.description}
                </div>
              </div>
            </fieldset>
            <div className="form-group row">
              <label
                className="col-form-label col-sm-2 pt-0"
                htmlFor="solutionCode"
              >
                Solution code
              </label>
              <div className="col-sm-10">
                <textarea
                  className="form-control"
                  id="solutionCode"
                  name="code"
                  rows="3"
                ></textarea>
              </div>
            </div>
            {this.renderFeedBack()}
            <div className="form-group row">
              <div className="col-sm-10">
                <button type="submit" className="btn btn-primary">
                  Submit
                </button>
              </div>
            </div>
          </>
        )}
      </form>
    );
  }

  renderFeedBack() {
    if (this.state.submitResult) {
      return this.state.submitResult.isCorrect ? (
        <div className="text-success">Solved successfully!</div>
      ) : (
        <>
          <div className="form-group row">
            <label className="col-form-label col-sm-2 pt-0 text-danger">
              Output
            </label>
            <div className="col-sm-10 text-danger">
              <div className="form-check">{this.state.submitResult.output}</div>
            </div>
          </div>
          <div className="form-group row">
            <label className="col-form-label col-sm-2 pt-0 text-info">
              Expected
            </label>
            <div className="col-sm-10 text-info">
              <div className="form-check">
                {this.state.submitResult.expected}
              </div>
            </div>
          </div>
        </>
      );
    } else {
      return null;
    }
  }
}
