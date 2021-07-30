export default function Paragrafo({children, className}) {
    return (
        <p className={`${className}`}>{children}</p>
    )
}