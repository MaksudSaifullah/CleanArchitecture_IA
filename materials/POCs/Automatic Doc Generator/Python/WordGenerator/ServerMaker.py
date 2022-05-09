from flask import Flask, request

import open_template

app = Flask(__name__)


@app.route("/", methods = ['GET', 'POST', 'DELETE'])
def home():
    json = request.get_json()
    return open_template.callable_from_others(json["coverPageDict"], json["sectionData"], json["detailedIssueTableContent"], json["graph"])


if __name__ == "__main__":
    app.run(debug=True)