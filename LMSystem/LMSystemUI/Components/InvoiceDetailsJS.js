export function showModal(elementId) {
    if (elementId != null && elementId != undefined) {
        let modalElement = document.getElementById(elementId);
        modalElement.style.display = "block";
        return "ok";
    } else { return "error"; }
}
